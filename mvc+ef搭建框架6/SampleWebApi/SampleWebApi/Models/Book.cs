namespace SampleWebApi.Models
{
    public class Book
    {
        /// <summary>
        /// 图书编号
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// 图书名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 图书价格
        /// </summary>
        public double Price { get; set; }
    }
}