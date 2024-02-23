using Core.Entities;

namespace Entities.Concretes;

public class Model:BaseEntity<int>
{
    public Guid BrandId { get; set; } //1
    public string Name { get; set; } //"A6"

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Car> Cars { get; set; }

    public Model()
    {
        Cars = new HashSet<Car>();
    }

    public Model(int id, Guid brandId, string name)
    {
        Id = id;
        BrandId = brandId;
        Name = name;
    }

}
