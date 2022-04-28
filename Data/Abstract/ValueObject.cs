namespace CrudAPI.Data.Abstract
{
    public abstract class ValueObject<TValue>
    {
        public readonly TValue Value;
        protected ValueObject(TValue value)
        {
            Value = value;
            Validate();
        }

        public static bool operator ==(ValueObject<TValue> left, ValueObject<TValue> right)
        {
            return EqualOperator(left, right);
        }

        public static bool operator !=(ValueObject<TValue> left, ValueObject<TValue> right)
        {
            return !(EqualOperator(left, right));
        }

        protected virtual bool Validate()
        {
            if (Value == null)
            {
                throw new ArgumentNullException("Value can't be null");
            }
            return true;
        }

        protected static bool EqualOperator(ValueObject<TValue> left, ValueObject<TValue> right)
        {
            if(ReferenceEquals(left, null) ^ ReferenceEquals(right,null))
            {
                return false;
            }
            return ReferenceEquals(left, null) || left.Equals(right);
        }

        protected static bool NotEqualOperator(ValueObject<TValue> left, ValueObject<TValue> right)
        {
            return !(EqualOperator(left, right));
        }

        public override bool Equals(object? obj)
        {
            if(obj == null || obj.GetType() != GetType())
            {
                return false;
            }

            var valueObject = (ValueObject<TValue>)obj;
            return valueObject.Value.Equals(Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }
    }
}
