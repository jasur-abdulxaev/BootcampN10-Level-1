namespace N28_HT2.Model
{
    public class ClonableList<T> : List<T>, ICloneable where T : ICloneable
    {
        public object Clone()
        {
            ClonableList<T> clonedList = new ClonableList<T>();
            foreach (T item in this)
            {
                clonedList.Add((T)item.Clone());
            }
            return clonedList;
        }
    }
}
