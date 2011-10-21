using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcRemoteValidationSample.Models;

namespace MvcRemoteValidationSample.Controllers {

    public class NorthwindController : Controller {

        NorthwindEntities _entities = new NorthwindEntities();

        public ActionResult Index() {

            var model = _entities.Products;

            return View(model);
        }

        public ActionResult Create() {

            registerCategoryVoidViewBag();

            return View();
        }

        private void registerCategoryVoidViewBag() {

            IList<SelectListItem> supplierSelectListItems = new List<SelectListItem>();
            IList<SelectListItem> categorieSelectListItems = new List<SelectListItem>();

            var suppliers = _entities.Suppliers;
            var categories = _entities.Categories;

            foreach (var item in suppliers) {

                supplierSelectListItems.Add(new SelectListItem { 
                    Text = item.Company_Name,
                    Value = item.Supplier_ID.ToString()
                });
            }

            foreach (var item in categories) {

                categorieSelectListItems.Add(new SelectListItem { 
                    Text = item.Category_Name,
                    Value = item.Category_ID.ToString()
                });
            }

            #region _viewbags

            ViewBag.SupplierSelectListItems = supplierSelectListItems;
            ViewBag.CategorieSelectListItems = categorieSelectListItems;

            #endregion

        }

        public JsonResult doesProductNameExistUnderCategory(int? Category_ID, string Product_Name) {

            var model = _entities.Products.Where(x => (Category_ID.HasValue) ? 
                    (x.Category_ID == Category_ID && x.Product_Name == Product_Name) : 
                    (x.Product_Name == Product_Name)
                );

            return Json(model.Count() == 0);

        }

    }
}
