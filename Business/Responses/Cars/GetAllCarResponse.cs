namespace Business.Responses.Cars;

public class GetAllCarResponse
{
    public int ModelId { get; set; }
    public string ModelName { get; set; }
    public string ModelBrandName { get; set; }
    public int ModelYear { get; set; }
    public string Plate { get; set; }
    public int State { get; set; }  // 1- Available 2- Rented 3-Under Maitenance
    public double DailyPrice { get; set; }
}


