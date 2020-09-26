﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EShopWebAPI.DTO;
using EShopWebAPI.Models;

namespace EShopWebAPI.Controllers
{
    public class ProductController : ApiController
    {
        // GET: Product
        public HttpResponseMessage Get()
        {
            using (EshopEntities db = new EshopEntities())
            {
                var result = db.Products.ToList();
                if (result != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, result.ToList());
                }
                else
                {
                    return null;
                }
            }
        }

        // GET: api/Product/5
        public ProductDTO Get(int id)
        {
            using (EshopEntities db = new EshopEntities())
            {
                Product c = db.Products.SingleOrDefault(x => x.ProductID == id);
                if (c != null)
                {
                    return new ProductDTO(c.ProductID, c.CategoryID, c.ProductName, c.UnitPrice, c.Quantity);
                }
                else
                {
                    return null;
                }
            }
        }

        // POST: api/Product
        public HttpResponseMessage Post([FromBody] Product value)
        {
            try
            {
                using (EshopEntities db = new EshopEntities())
                {
                    db.Products.Add(value);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // PUT: api/Product/5
        public HttpResponseMessage Put(int id, [FromBody] Product value)
        {
            try
            {

                using (EshopEntities db = new EshopEntities())
                {
                    Product s = db.Products.SingleOrDefault(b => b.ProductID == id);
                    if (s != null)
                    {
                        s.ProductID = id;
                        s.CategoryID = value.CategoryID;
                        s.UnitPrice = value.UnitPrice;
                        s.ProductName = value.ProductName;
                        s.Quantity = value.Quantity;
                        db.SaveChanges();
                        return Request.CreateResponse(HttpStatusCode.OK, s);
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        // DELETE: api/Product/5
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                using (EshopEntities db = new EshopEntities())
                {
                    Product s = db.Products.SingleOrDefault(x => x.ProductID == id);
                    db.Products.Remove(s);
                    db.SaveChanges();
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }
        }
    }
}