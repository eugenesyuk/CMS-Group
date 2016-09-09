using System;
using System.Collections.Generic;
using System.Linq;
using DB.Resources;

namespace DB.DAL {
	public class SliderRepository : EntityRepository, ISliderRepository {
		public bool CreateSlider(string url, string imageUrl, Language lang, int order) {
			SIteSlider slider = new SIteSlider();
			slider.Url = url;
			slider.ImageUrl = imageUrl;
			slider.Language = lang.Id;
			slider.Order = (short) order;
			DbEntities.SIteSliders.Add(slider);
			DbEntities.SaveChanges();
			return DbEntities.SIteSliders.Any(x => x.Id.Equals(slider.Id));
		}

		public List<SIteSlider> GetAll(Language lang) {
			return DbEntities.SIteSliders.Where(x => x.Language == lang.Id).OrderBy(x => x.Order).ToList();
		}

		public SIteSlider GetSliderByOrder(int order) {
			return DbEntities.SIteSliders.FirstOrDefault(x => x.Order.Equals(order));
		}

		public SIteSlider GetSliderByUrl(string url) {
			return DbEntities.SIteSliders.FirstOrDefault(x => x.Url.Equals(url));
		}

		public bool UpdateSliderByOrder(int order, string url, string imageUrl, Language lang, int newOrder) {
			var slider = DbEntities.SIteSliders.FirstOrDefault(x => x.Order.Equals(order));
			if(slider == null)
				throw new NullReferenceException();
			slider.Order = (short) newOrder;
			slider.Url = url;
			slider.ImageUrl = imageUrl;
			slider.Language = lang.Id;
			DbEntities.SaveChanges();
			return DbEntities.SIteSliders.Any(x => x.Order.Equals(newOrder));
		}

		public bool UpdateSliderByUrl(string url, string newUrl, string imageUrl, Language lang, int order) {
			var slider = DbEntities.SIteSliders.FirstOrDefault(x => x.Url.Equals(url));
			if(slider == null)
				throw new NullReferenceException(Errors.SliderNotExists);
			slider.Order = (short) order;
			slider.Url = newUrl;
			slider.ImageUrl = imageUrl;
			slider.Language = lang.Id;
			DbEntities.SaveChanges();
			return DbEntities.SIteSliders.Any(x => x.Url.Equals(newUrl));
		}

		public bool DeleteSliderByUrl(string url) {
			var slider = DbEntities.SIteSliders.FirstOrDefault(x => x.Url.Equals(url));
			if(slider == null)
				throw new NullReferenceException(Errors.SliderNotExists);
			DbEntities.SIteSliders.Remove(slider);
			DbEntities.SaveChanges();
			return !DbEntities.SiteMenus.Any(x => x.Id.Equals(slider.Id));
		}

		public bool DeleteSliderByOrder(int order) {
			var slider = DbEntities.SIteSliders.FirstOrDefault(x => x.Order.Equals(order));
			if(slider == null)
				throw new NullReferenceException(Errors.SliderNotExists);
			DbEntities.SIteSliders.Remove(slider);
			DbEntities.SaveChanges();
			return !DbEntities.SiteMenus.Any(x => x.Id.Equals(slider.Id));
		}
	}
}
