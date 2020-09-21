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

        public List<ProductModel> GetAllProducts()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<ProductModel> products = new List<ProductModel>();

                products = connection.Query<ProductModel>("dbo.spGetAllProducts", commandType: CommandType.StoredProcedure).ToList(); ;

                return products;
            }
        }

        public List<TagModel> GetTags()
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                List<TagModel> tags = new List<TagModel>();

                tags = connection.Query<TagModel>("dbo.spGetTags", commandType: CommandType.StoredProcedure).ToList();

                return tags;
            }
        }

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

        public ProductModel ToggleProductNeedsRefill(ProductModel productModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", productModel.id);
                //p.Add("@NeedsRefill", 0, dbType: DbType.Boolean, direction: ParameterDirection.Output);

                connection.Execute("dbo.spToggleProductNeedsRefill", p, commandType: CommandType.StoredProcedure);

                //productModel.NeedsRefill = p.Get<bool>("@NeedsRefill");
                productModel.NeedsRefill = !productModel.NeedsRefill;
                // TODO - Might go back and fix this to return the updated product from the DB instead of assuming the change.

                return productModel;
            }
        }



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

        public void DeleteProduct(ProductModel productModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var p = new DynamicParameters();
                p.Add("@id", productModel.id);

                connection.Execute("dbo.spDeleteProduct", p, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteTag(TagModel tagModel)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(GlobalConfig.CnnString(db)))
            {
                var t = new DynamicParameters();
                t.Add("@id", tagModel.id);

                connection.Execute("dbo.spDeleteTag", t, commandType: CommandType.StoredProcedure);
            }
        }
    }
}
