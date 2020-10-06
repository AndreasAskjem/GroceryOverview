using GroceryOverviewLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryOverviewLibrary.DataAccess
{
    public interface IDataConnection
    {
        void AddProduct(ProductModel productModel);
        List<ProductModel> GetAllProducts();
        List<TagModel> GetAllTags();
        List<TagModel> GetTagsBelongingToProduct(ProductModel productModel);
        List<ProductModel> GetProductsFilteredByTag(TagModel tagModel);
        ProductModel ToggleProductNeedsRefill(ProductModel ProductModel);
        void ToggleProductTagRelation(ProductModel productModel, TagModel tagModel);
        void DeleteProduct(ProductModel productModel);
        TagModel AddTag(TagModel tagModel);
        void DeleteTag(TagModel tagModel);
        List<ProductModel> GetProductsBySearch(string searchWord);
    }
}
