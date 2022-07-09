using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;

namespace BusinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryRepository _categoryRepository;

        public CategoryManager(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public void TAdd(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryRepository.Add(entity);
        }

        public void TUptade(Category entity)
        {
            _categoryRepository.Add(entity);
        }
        public Category GetByID(int id)
        {
            return _categoryRepository.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryRepository.GetAll();
        }

    }
}
