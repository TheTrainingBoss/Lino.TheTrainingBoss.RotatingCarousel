/* ------------------------------------------------------------------------------
<auto-generated>
    This file was generated by Sitefinity CLI v1.1.0.1
</auto-generated>
------------------------------------------------------------------------------ */

using RotatingCarousel.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Telerik.Sitefinity.Frontend.Mvc.Infrastructure.Controllers.Attributes;
using Telerik.Sitefinity.GenericContent.Model;
using Telerik.Sitefinity.Libraries.Model;
using Telerik.Sitefinity.Modules.Libraries;
using Telerik.Sitefinity.Mvc;
using Telerik.Sitefinity.Personalization;
using Telerik.Sitefinity.Web.UI;

namespace RotatingCarousel.Mvc.Controllers
{
    [EnhanceViewEnginesAttribute]
    [ControllerToolboxItem(Name = "RotatingImageCarousel_MVC", 
        Title = "Rotating Image Carousel", 
        SectionName = "The Training Boss",
        CssClass = "RotatingCarouselIcon sfMvcIcn")]
    public class RotatingImageCarouselController : Controller, IPersonalizable
	{
		// GET: RotatingImageCarousel
		public ActionResult Index()
		{
            if (!string.IsNullOrEmpty(this.AlbumName))
            {
                var albumimages = GetImagesFromAlbum(this.AlbumName);
                var model = new RotatingImageCarouselModel(albumimages);
                return View("Default", model);
            }
            else
            {
                return Content("Please Choose an Album Name for Display");
            }
		}
		
        protected override void HandleUnknownAction(string actionName)
        {
            this.ActionInvoker.InvokeAction(this.ControllerContext, "Index");
        }

        public List<Image> GetImagesFromAlbum(string albumTitle)
        {
            LibrariesManager lm = LibrariesManager.GetManager();
            return lm.GetImages()
                .Where(i => i.Status == ContentLifecycleStatus.Live && i.Parent.Title == albumTitle).ToList();
        }

		public string AlbumName { get; set; }
	}
}