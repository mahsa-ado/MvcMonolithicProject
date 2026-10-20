namespace FirstMonolithicProject.ApplicationServices.Dtos.ProductDtos
{
    public class GetProductDtoById
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal UnitPrice { get; set; }
        public string DescriptionRecord { get; set; }
    }
}
