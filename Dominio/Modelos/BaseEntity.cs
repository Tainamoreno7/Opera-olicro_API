using System;
using FluentValidation;
using FluentValidation.Results;
using Newtonsoft.Json;
using NHibernate.Proxy;
using System.Linq;
using System.Collections.Generic;
using Dominio.Extensions;

namespace Dominio.Modelos
{
    public abstract class BaseEntity
    {
        public virtual Guid Id { get; set; }
        public virtual bool Valid { get; set; }
        public virtual bool Invalid => !Valid;
        public virtual ValidationResult ValidationResult { get; set; }

        public virtual void AddNotification(string key, string message)
        {
            var validationFailure = new ValidationFailure(key, message);

            if (ValidationResult == null)
                ValidationResult = new ValidationResult();

            ValidationResult.Errors.Add(validationFailure);
            Valid = ValidationResult.IsValid;
        }

        public virtual bool Validate<TModel>(TModel model, AbstractValidator<TModel> validator)
        {
            if (ValidationResult != null && ValidationResult.Errors.Any())
                return Valid = false;

            ValidationResult = validator.Validate(model);

            return Valid = ValidationResult.IsValid;
        }

        public override bool Equals(object obj)
        {
            var other = obj as BaseEntity;

            if (ReferenceEquals(other, null))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (GetRealType() != other.GetRealType())
                return false;

            if (Id == Guid.Empty || other.Id == Guid.Empty)
                return false;

            return Id == other.Id;
        }

        public static bool operator ==(BaseEntity a, BaseEntity b)
        {
            if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
                return true;

            if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
                return false;

            return a.Equals(b);
        }

        public static bool operator !=(BaseEntity a, BaseEntity b)
        {
            return !(a == b);
        }

        public override int GetHashCode()
        {
            return (GetRealType().ToString() + Id).GetHashCode();
        }

        private Type GetRealType()
        {
            return NHibernateProxyHelper.GetClassWithoutInitializingProxy(this);
        }

        private Tracking _tracking;

        protected virtual Tracking Tracking
        {
            get { return _tracking ?? (_tracking = new Tracking()); }
            set { _tracking = value; }
        }

        public virtual string LastUpdate
        {
            get
            {
                if (Tracking.Insert == null && Tracking.Update == null)
                {
                    return null;
                }
                return JsonConvert.SerializeObject(Tracking, Formatting.None);
            }
            set
            {
                if (string.IsNullOrEmpty(value) || !value.ValidateJSON())
                {
                    _tracking = null;
                    return;
                }
                _tracking = JsonConvert.DeserializeObject<Tracking>(value);
            }
        }

        public virtual void UpdateTracking(string userName, int sequence)
        {
            if (Id == Guid.Empty)
            {
                Tracking.Insert = new TrackInformation { Date = DateTime.UtcNow.ToLocalTime(), UserName = $"{userName} ({sequence.ToString()})" };
            }
            else
            {
                Tracking.Update = new TrackInformation { Date = DateTime.UtcNow.ToLocalTime(), UserName = $"{userName} ({sequence.ToString()})" };
            }
        }
        protected virtual void AddToList<T>(IEnumerable<T> list, T item, Action<T> preProcessAction)
            where T : BaseEntity
        {
            if (item == null)
            {
                return;
            }
            preProcessAction?.Invoke(item);
            ((IList<T>)list).Add(item);
        }
    }
}
