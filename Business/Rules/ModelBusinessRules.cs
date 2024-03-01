using Business.Abstracts;
using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using Entities.Concretes;

namespace Business.Rules;

public class ModelBusinessRules:BaseBusinessRules
{
    private IBrandService _brandService;

    public ModelBusinessRules(IBrandService brandService)
    {
        _brandService = brandService;
    }

    public async Task CheckIfBrandExists(Guid brandId)
    {
        Brand? brand = await _brandService.GetById(brandId);
        if (brand is null) throw new BusinessException("Brand not exists");

    }
}
