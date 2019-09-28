# Lino.TheTrainingBoss.RotatingCarousel
This is a sample Sitefinity MVC widget to show how to build one in an external assembly and assign a new icon for it in the Sitefinity Designer

![](./VideoGIF/LinoDoh400.jpg)

How to install it in your site?
-------------------------------
The only file you need is the assembly file **Lino.TheTrainingBoss.RotatingCarousel.dll**  
I placed this assembly here in the repository in case you just want to use it right away and you might not yet be interested in the source code.
[The binary](https://github.com/TheTrainingBoss/Lino.TheTrainingBoss.RotatingCarousel/blob/master/Binary%20Release/Lino.TheTrainingBoss.RotatingCarousel.dll)

Place that file in your bin folder of your Sitefinity site (currently it is compiled against 12.1.7100)  if you have a different version of Sitefinity just add Assembly Binding Dependencies in your Web.Config file to get it to work.
Or better yet, open the project in Visual Studio and upgrade or downgrade the NuGet packages to meet your sitefinity version needs.

![](./VideoGIF/RotatingCarousel.gif)

How to use the Widget?
----------------------
The only property available in the Widget Designer is the **Album Name**, enter the name of the Sitefinity library or Album that you wish to display its images in the Rotating Carousel and Voila!

For Developers:
---------------
If you are interested in the source code, it is a pretty straight forward widget.  The couple of items that I would like to show in this Widgets source code are:
- Notice how the icon was assigned to the widget in the Controller file in the attribute [ControllerToolboxItem]
```
[ControllerToolboxItem(Name = "RotatingImageCarousel_MVC", 
        Title = "Rotating Image Carousel", 
        SectionName = "The Training Boss",
        CssClass = "RotatingCarouselIcon sfMvcIcn")]
```
- The sfMvcIcn part is the little blue icon that shows up in the bottom right corner of each MVC widget.
- The AssemblyInfo.cs file under properties needs to have the **ControllerContainer** assembly directive declared to allow Sitefinity to know that the assembly has widgets in it. You also need to decalre the WebResource of where your css file is located in the assembly to allow your 50x30 icon of the widget in the designer to be found.
```
[assembly: ControllerContainer()]
[assembly: WebResource("Lino.TheTrainingBoss.RotatingCarousel.Css.main.css", 
    "text/css", PerformSubstitution = true)]
```
- The final thing I wanted to grab your attention for is the way you access the resource in the assembly from your views
```
@Html.StyleSheet(Url.EmbeddedResource("RotatingCarousel.Mvc.Models.RotatingImageCarouselModel",
    "Lino.TheTrainingBoss.RotatingCarousel.Css.main.css"))
```
The first part could be ANY class inside on your assembly, I chose here for it to be the model, but it could have been the controller, if I wanted to.  The second part needs to be the Type namesapce path to the css file.

Enjoy, modify, use, add to it and have fun!
