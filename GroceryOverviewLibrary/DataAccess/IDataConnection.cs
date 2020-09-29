using GroceryOverviewLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace GroceryOverviewLibrary.DataAccess
{
    public interface IDataConnection
    {
        ProductModel AddProduct(ProductModel model);
        List<ProductModel> GetAllProducts();
        List<TagModel> GetTags();
        List<TagModel> GetTagsBelongingToProduct(ProductModel productModel);
        List<ProductModel> GetProductsFilteredByTag(TagModel tagModel);
        ProductModel ToggleProductNeedsRefill(ProductModel ProductModel);
        void ToggleProductTagRelation(ProductModel product, TagModel tag);
        void DeleteProduct(ProductModel productModel);
        TagModel AddTag(TagModel tagModel);
        void DeleteTag(TagModel tagModel);
        List<ProductModel> GetProductsBySearch(string searchWord);
    }
}
