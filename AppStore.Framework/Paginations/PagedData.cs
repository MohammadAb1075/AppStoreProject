namespace AppStore.Framework.Paginations
{
    public class PagedData<T>
    {
        public List<T>? Data { get; set; }
        public PageInfo? PageInfo { get; set; }
    }
}
//namespace AppStore.Framework.Paginations
//{
//    public class PagedData<T>
//    {

//        private readonly List<T>? _data;

//        public IReadOnlyList<T> Data
//        {
//            get
//            {
//                return _data.AsReadOnly();
//            }
//        }
//        //public List<T> Data { get; set; }
//        public PageInfo PageInfo { get; set; }
//    }
//}