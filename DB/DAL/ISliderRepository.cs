using System.Collections.Generic;

namespace DB.DAL {
	public interface ISliderRepository {
		bool CreateSlider(string url, string imageUrl, Language lang, int order);
		List<SIteSlider> GetAll(Language lang);
		SIteSlider GetSliderByOrder(int order);
		SIteSlider GetSliderByUrl(string url);
		bool UpdateSliderByOrder(int order, string url, string imageUrl, Language lang, int newOrder);
		bool UpdateSliderByUrl(string url, string newUrl, string imageUrl, Language lang, int order);
		bool DeleteSliderByUrl(string url);
		bool DeleteSliderByOrder(int order);
	}
}
