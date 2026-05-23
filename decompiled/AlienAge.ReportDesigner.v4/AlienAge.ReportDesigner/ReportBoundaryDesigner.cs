using AlienAge.ReportDesigner.Properties;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraBars.Ribbon.Gallery;

namespace AlienAge.ReportDesigner;

public static class ReportBoundaryDesigner
{
	public static void InitBoundaryGallery(RibbonGalleryBarItem ribbonGalleryBarItem)
	{
		ribbonGalleryBarItem.Caption = "ribbonGalleryBarItem";
		ribbonGalleryBarItem.Gallery.AllowHoverImages = true;
		ribbonGalleryBarItem.Gallery.AllowMarqueeSelection = true;
		ribbonGalleryBarItem.Gallery.ColumnCount = 3;
		GalleryDropDown galleryDropDown = new GalleryDropDown();
		GalleryControlGallery galleryControlGallery = new GalleryControlGallery();
		GalleryItemGroup galleryItemGroup = new GalleryItemGroup();
		GalleryItem galleryItem = new GalleryItem();
		GalleryItem galleryItem2 = new GalleryItem();
		GalleryItem galleryItem3 = new GalleryItem();
		GalleryItem galleryItem4 = new GalleryItem();
		GalleryItem galleryItem5 = new GalleryItem();
		GalleryItemGroup galleryItemGroup2 = new GalleryItemGroup();
		GalleryItem galleryItem6 = new GalleryItem();
		GalleryItemGroup galleryItemGroup3 = new GalleryItemGroup();
		GalleryItem galleryItem7 = new GalleryItem();
		GalleryItem galleryItem8 = new GalleryItem();
		GalleryItem galleryItem9 = new GalleryItem();
		GalleryItem galleryItem10 = new GalleryItem();
		GalleryItemGroup galleryItemGroup4 = new GalleryItemGroup();
		GalleryItem galleryItem11 = new GalleryItem();
		GalleryItem galleryItem12 = new GalleryItem();
		GalleryItem galleryItem13 = new GalleryItem();
		GalleryItem galleryItem14 = new GalleryItem();
		GalleryItem galleryItem15 = new GalleryItem();
		GalleryItemGroup galleryItemGroup5 = new GalleryItemGroup();
		GalleryItem galleryItem16 = new GalleryItem();
		GalleryItem galleryItem17 = new GalleryItem();
		GalleryItem galleryItem18 = new GalleryItem();
		GalleryItem galleryItem19 = new GalleryItem();
		GalleryItem galleryItem20 = new GalleryItem();
		galleryItemGroup.Caption = "Alien Age Boundaries";
		galleryItem.Caption = "Default";
		galleryItem.Hint = "No Borders";
		galleryItem.HoverImage = Resources.DefaultNoImage;
		galleryItem.Image = Resources.DefaultNoImage;
		galleryItem2.Caption = "Art Obsession";
		galleryItem2.Hint = "Art Obsession";
		galleryItem2.HoverImage = Resources.ArtObsessionImage;
		galleryItem2.Image = Resources.ArtObsessionImage;
		galleryItem3.Caption = "Classic";
		galleryItem3.Hint = "Classic";
		galleryItem3.HoverImage = Resources.ClassicImage;
		galleryItem3.Image = Resources.ClassicImage;
		galleryItem4.Caption = "Grandmother";
		galleryItem4.Hint = "Grandmother";
		galleryItem4.HoverImage = Resources.GrandmotherImage;
		galleryItem4.Image = Resources.GrandmotherImage;
		galleryItem5.Caption = "Summertime";
		galleryItem5.Hint = "Summertime";
		galleryItem5.HoverImage = Resources.SummertimeImage;
		galleryItem5.Image = Resources.SummertimeImage;
		galleryItemGroup.Items.AddRange(new GalleryItem[6] { galleryItem, galleryItem2, galleryItem3, galleryItem4, galleryItem5, galleryItem18 });
		ribbonGalleryBarItem.Gallery.Groups.AddRange(new GalleryItemGroup[1] { galleryItemGroup });
		ribbonGalleryBarItem.Gallery.ItemCheckMode = ItemCheckMode.SingleCheck;
		ribbonGalleryBarItem.Gallery.ItemCheckedChanged += ribbonGalleryBarItem1_Gallery_ItemCheckedChanged;
		ribbonGalleryBarItem.GalleryDropDown = galleryDropDown;
		ribbonGalleryBarItem.Id = 847;
		ribbonGalleryBarItem.Name = "ribbonGalleryBarItem";
		ribbonGalleryBarItem.RememberLastCommand = true;
		galleryDropDown.Gallery.AllowHoverImages = true;
		galleryDropDown.Gallery.AllowMarqueeSelection = false;
		galleryDropDown.Gallery.CheckDrawMode = CheckDrawMode.ImageAndText;
		galleryItemGroup2.Caption = "Default";
		galleryItem6.Caption = "No Borders";
		galleryItem6.Hint = "No Borders";
		galleryItem6.HoverImage = Resources.DefaultNoImage;
		galleryItem6.Image = Resources.DefaultNoImage;
		galleryItemGroup2.Items.AddRange(new GalleryItem[1] { galleryItem6 });
		galleryItemGroup3.Caption = "Art";
		galleryItem7.Caption = "Art Obsession";
		galleryItem7.Hint = "Art Obsession";
		galleryItem7.HoverImage = Resources.ArtObsessionImage;
		galleryItem7.Image = Resources.ArtObsessionImage;
		galleryItem8.Caption = "Classic";
		galleryItem8.Hint = "Classic";
		galleryItem8.HoverImage = Resources.ClassicImage;
		galleryItem8.Image = Resources.ClassicImage;
		galleryItem9.Caption = "Grandmother";
		galleryItem9.Hint = "Grandmother";
		galleryItem9.HoverImage = Resources.GrandmotherImage;
		galleryItem9.Image = Resources.GrandmotherImage;
		galleryItem10.Caption = "Summertime";
		galleryItem10.Hint = "Summertime";
		galleryItem10.HoverImage = Resources.SummertimeImage;
		galleryItem10.Image = Resources.SummertimeImage;
		galleryItemGroup3.Items.AddRange(new GalleryItem[6] { galleryItem7, galleryItem8, galleryItem9, galleryItem10, galleryItem19, galleryItem20 });
		galleryItemGroup4.Caption = "Nature";
		galleryItem11.Caption = "Candy Party";
		galleryItem11.Hint = "Candy Party";
		galleryItem11.HoverImage = Resources.CandyPartyImage;
		galleryItem11.Image = Resources.CandyPartyImage;
		galleryItem12.Caption = "Curious Bird";
		galleryItem12.Hint = "Curious Bird";
		galleryItem12.HoverImage = Resources.Curious_BirdImage;
		galleryItem12.Image = Resources.Curious_BirdImage;
		galleryItem13.Caption = "Festive Season";
		galleryItem13.Hint = "Festive Season";
		galleryItem13.HoverImage = Resources.Festive_SeasonImage;
		galleryItem13.Image = Resources.Festive_SeasonImage;
		galleryItem14.Caption = "Forbidden Tree";
		galleryItem14.Hint = "Forbidden Tree";
		galleryItem14.HoverImage = Resources.Forbidden_TreeImage;
		galleryItem14.Image = Resources.Forbidden_TreeImage;
		galleryItem15.Caption = "Green House";
		galleryItem15.Hint = "Green House";
		galleryItem15.HoverImage = Resources.Green_HouseImage;
		galleryItem15.Image = Resources.Green_HouseImage;
		galleryItemGroup4.Items.AddRange(new GalleryItem[5] { galleryItem11, galleryItem12, galleryItem13, galleryItem14, galleryItem15 });
		galleryItemGroup5.Caption = "Pencil Sketch";
		galleryItem16.Caption = "Elegant";
		galleryItem16.Hint = "Elegant";
		galleryItem16.HoverImage = Resources.ElegantImage;
		galleryItem16.Image = Resources.ElegantImage;
		galleryItem17.Caption = "Sketch Mania";
		galleryItem17.Hint = "Sketch Mania";
		galleryItem17.HoverImage = Resources.Sketch_ManiaImage;
		galleryItem17.Image = Resources.Sketch_ManiaImage;
		galleryItem18.Caption = "Alien Age";
		galleryItem18.Hint = "Alien Age";
		galleryItem18.HoverImage = Resources.alienageImage;
		galleryItem18.Image = Resources.alienageImage;
		galleryItem19.Caption = "Alien Age";
		galleryItem19.Hint = "Alien Age";
		galleryItem19.HoverImage = Resources.alienageImage;
		galleryItem19.Image = Resources.alienageImage;
		galleryItem20.Caption = "Birthday Cake";
		galleryItem20.Hint = "Birthday Cake";
		galleryItem20.HoverImage = Resources.BirthdayCakeImage;
		galleryItem20.Image = Resources.BirthdayCakeImage;
		galleryItemGroup5.Items.AddRange(new GalleryItem[2] { galleryItem16, galleryItem17 });
		galleryDropDown.Gallery.Groups.AddRange(new GalleryItemGroup[4] { galleryItemGroup2, galleryItemGroup3, galleryItemGroup4, galleryItemGroup5 });
		galleryDropDown.Gallery.ItemCheckMode = ItemCheckMode.SingleRadio;
		galleryDropDown.Gallery.RowCount = 4;
		galleryDropDown.Gallery.ShowItemText = true;
		galleryDropDown.Gallery.ItemCheckedChanged += galleryDropDown1_Gallery_ItemCheckedChanged;
		galleryDropDown.Name = "galleryDropDown1";
		galleryDropDown.ShowCaption = true;
	}

	private static void galleryDropDown1_Gallery_ItemCheckedChanged(object sender, GalleryItemEventArgs e)
	{
		if (e.Item.Checked)
		{
			ReportBoundaryHangler.SaveBoundaryToMemory(e.Item.Caption);
		}
	}

	private static void ribbonGalleryBarItem1_Gallery_ItemCheckedChanged(object sender, GalleryItemEventArgs e)
	{
		if (e.Item.Checked)
		{
			ReportBoundaryHangler.SaveBoundaryToMemory(e.Item.Caption);
		}
	}
}
