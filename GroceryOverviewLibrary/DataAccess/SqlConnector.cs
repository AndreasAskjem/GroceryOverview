using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using Dapper;
using GroceryOverviewLibrary.Models;

namespace GroceryOverviewLibrary.DataAccess
{
    public class SqlConnector : IDataConnection
    {
        private const string db = "GroceryOverview";


        /// <summary>
        /// Saves a new product to the database.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public ProductModel AddProduct(ProductModel productModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@Name", productModel.Name);
                p.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spCreateProduct", p, commandType: CommandType.StoredProcedure);

                productModel.id = p.Get<int>("@id");
                return productModel;
            }
        }

        /// <summary>
        ///  Saves a new tag to the database.
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public TagModel AddTag(TagModel tagModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var t = new DynamicParameters();
                t.Add("@Name", tagModel.Name);
                t.Add("@id", 0, dbType: DbType.Int32, direction: ParameterDirection.Output);

                connection.Execute("dbo.spCreateTag", t, commandType: CommandType.StoredProcedure);

                tagModel.id = t.Get<int>("@id");
                return tagModel;
            }
        }

        /// <summary>
        ///  Gets all products from the database.
        /// </summary>
        /// <returns></returns>
        public List<ProductModel> GetAllProducts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<ProductModel> products = new List<ProductModel>();

                products = connection.Query<ProductModel>("dbo.spGetAllProducts", commandType: CommandType.StoredProcedure).ToList(); ;

                return products;
            }
        }

        /// <summary>
        /// Gets all tags from the database.
        /// </summary>
        /// <returns></returns>
        public List<TagModel> GetTags()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<TagModel> tags = new List<TagModel>();

                tags = connection.Query<TagModel>("dbo.spGetTags", commandType: CommandType.StoredProcedure).ToList();

                return tags;
            }
        }

        /// <summary>
        /// Gets all products that are connected to the specific tag.
        /// </summary>
        /// <param name="tagModel"></param>
        /// <returns></returns>
        public List<ProductModel> GetProductsFilteredByTag(TagModel tagModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<ProductModel> products = new List<ProductModel>();

                var p = new DynamicParameters();
                p.Add("@Tag", tagModel.Name);

                products = connection.Query<ProductModel>("dbo.spGetProductsFilteredByTag", p, commandType: CommandType.StoredProcedure).ToList();

                return products;
            }
        }

        /// <summary>
        /// Gets all the tags that are connected to a specific procuct.
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public List<TagModel> GetTagsBelongingToProduct(ProductModel productModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<TagModel> tags = new List<TagModel>();

                var t = new DynamicParameters();
                t.Add("@id", productModel.id);

                tags = connection.Query<TagModel>("dbo.spGetTagsBelongingToProduct", t, commandType: CommandType.StoredProcedure).ToList();

                return tags;
            }
        }

        /// <summary>
        /// Toggles the "NeedsRefill" value of a product.
        /// </summary>
        /// <param name="productModel"></param>
        /// <returns></returns>
        public ProductModel ToggleProductNeedsRefill(ProductModel productModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", productModel.id);
                p.Add("@NeedsRefill", 0, dbType: DbType.Boolean, direction: ParameterDirection.Output);

                connection.Execute("dbo.spToggleProductNeedsRefill", p, commandType: CommandType.StoredProcedure);

                productModel.NeedsRefill = p.Get<bool>("@NeedsRefill");

                return productModel;
            }
        }

        /// <summary>
        /// Adds a connection between tag and product if it doesn't exist.
        /// Removes the connection if it does exist.
        /// </summary>
        /// <param name="product"></param>
        /// <param name="tag"></param>
        public void ToggleProductTagRelation(ProductModel product, TagModel tag)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@productId", product.id);
                p.Add("@tagId", tag.id);

                connection.Execute("dbo.spToggleProductTagRelation", p, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Deletes the product from the database.
        /// </summary>
        /// <param name="productModel"></param>
        public void DeleteProduct(ProductModel productModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", productModel.id);

                connection.Execute("dbo.spDeleteProduct", p, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Deletes the tag from the database.
        /// </summary>
        /// <param name="tagModel"></param>
        public void DeleteTag(TagModel tagModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var t = new DynamicParameters();
                t.Add("@id", tagModel.id);

                connection.Execute("dbo.spDeleteTag", t, commandType: CommandType.StoredProcedure);
            }
        }

        public List<ProductModel> GetProductsBySearch(string searchWord)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<ProductModel> products = new List<ProductModel>();

                var p = new DynamicParameters();
                p.Add("@Search", searchWord);

                products = connection.Query<ProductModel>("dbo.spGetProductsFilteredBySearch", p, commandType: CommandType.StoredProcedure).ToList();

                return products;
            }
        }
    }
}
