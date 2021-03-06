﻿using DigitArc.ProductModule.DataAccess.DatabaseLogic;
using DigitArc.ProductModule.Entities.Models;
using System.Collections.Generic;
using System.Linq;

namespace DigitArc.ProductModule.Business.Logic
{
    public class ProductModuleManager : IProductModuleservice
    {
        private IProductRepository _productRepository;

        public ProductModuleManager(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product product)
        {
            _productRepository.Add(product);
        }

        public void Delete(Product product)
        {
            _productRepository.Delete(product);
        }

        public List<Product> GetAll()
        {
            return _productRepository.GetAll().ToList();
        }

        public Product GetById(int Id)
        {
           return  _productRepository.GetById(Id);
        }

        public void Save()
        {
            _productRepository.Save();
        }

        public void Update(Product product)
        {
            _productRepository.Update(product);
        }
    }
}