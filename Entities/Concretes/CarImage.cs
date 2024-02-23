using Core.Entities;

namespace Entities.Concretes;

public class CarImage:BaseEntity<Guid>
{
    public int CarId { get; set; } 
    public string ImagePath { get; set; }


    public virtual Car Car { get; set; }

    public CarImage()
    {
        
    }

    public CarImage(Guid id,int carId, string imagePath):this()
    {
        Id = id;
        CarId = carId;
        ImagePath = imagePath;
    }
}
