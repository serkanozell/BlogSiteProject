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

        public void CategoryAdd(Category category)
        {
            _categoryRepository.Add(category);
        }

        public void CategoryDelete(Category category)
        {
            _categoryRepository.Delete(category);
        }

        public void CategoryUpdate(Category category)
        {
            _categoryRepository.Update(category);
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
