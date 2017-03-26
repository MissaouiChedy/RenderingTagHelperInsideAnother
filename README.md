# RenderingTagHelperInsideAnother

Full code for the [Rendering a tag helper inside another tag helper](http://blog.techdominator.com/article/rendering-a-tag-helper-inside-another-tag-helper.html) and [Revisiting Programmatic Tag Helper Rendering](http://blog.techdominator.com/article/revisiting-programmatic-tag-helper-rendering.html) posts on the TechDominator Blog.

# Guidelines

This is a Visual Studio 2017 Asp.net Core (.net core runtime) project. Installation instructions can be found [here](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-mvc-app/start-mvc).

**This project was initially a Visual Studio 2015** Asp.net Core (.net core runtime) project and was converted to the new MsBuild format by running `dotnet migrate`. Visual Studio 2015 installation instructions can be found [here](https://github.com/aspnet/Docs/blob/master/aspnetcore/common/_static/aspnet-core-project-json.pdf).

Code for the [Rendering a tag helper inside another tag helper](http://blog.techdominator.com/article/rendering-a-tag-helper-inside-another-tag-helper.html) post is marked by the "OldVersion" tag and is in the VS 2015 format.

The most recent commit contains the code for the [Revisiting Programmatic Tag Helper Rendering](http://blog.techdominator.com/article/revisiting-programmatic-tag-helper-rendering.html) which is in the new VS 2017 format.

Tag helpers used in the post are defined under the `src/RenderingTagHelperInsideAnother/TagHelpers` folder and are used in the `Index` view.
