using AutoMapper;
using Cadastro.Domain.Entities;
using Cadastro.Domain.Interfaces;
using Cadastro.Interfaces;
using Cadastro.ViewModels;
using System.Collections.Generic;

namespace Cadastro.Services
{
    public class ProductsViewModelService : IProductViewModelService 
    {
        private readonly IProductRepository _productRepository;
        private readonly IClientViewModelService _clientService;
        private readonly IMapper _mapper;

        public ProductsViewModelService(IProductRepository productRepository, IMapper mapper, IClientViewModelService clientService)
        {
            _productRepository = productRepository;
            _mapper = mapper;
            _clientService = clientService;
        }

        public void Delete(int id)
        {
            _productRepository.Delete(id);
        }

        public ProductViewModel Get(int id)
        {
            var entity = _productRepository.Get(id);
            if (entity == null)
                return null;

            return _mapper.Map<ProductViewModel>(entity);
        }

        public IEnumerable<ProductViewModel> GetAll()
        {
            var list = _productRepository.GetAll();
            if (list == null)
                return new ProductViewModel[] { };

            foreach (var product in list)
            {
                var client = _clientService.Get(product.IdCategory);
                product.Category = _mapper.Map<Category>(client);
            }

            return _mapper.Map<IEnumerable<ProductViewModel>>(list);
        }

        public void Insert(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Insert(entity);
        }

        public void Update(ProductViewModel viewModel)
        {
            var entity = _mapper.Map<Product>(viewModel);

            _productRepository.Update(entity);
        }
    }
}
