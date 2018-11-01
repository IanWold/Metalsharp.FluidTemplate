# MetalsharpFluidTemplate

A [Metalsharp plugin]() using [Fluid]() to let you define [Liquid templates]().

## How it works

**1. Create your Liquid template file and include it in your Metalsharp project directory**

Here's an example template called `layout.template`:

```plaintext
<html>
<head><title>{{title}}</title></head>
<body>
<h1>{{title}}</h1>
{{content}}
</body>
</html>
```

**2. Specify a metadata object with key "layout" to point to the path of the template file**

Let's assume our project directory also contains `index.md`. Here's how to specify the layout in the frontmatter:

```md
---
title: "Hello!"
layout: "layout.template"
---
Hello, World!
```

**3. Use `FluidTemplate` in your Metalsharp plugin stack**

```c#
new Metalsharp("Site")    // Reads the files in the directory `/Site/` to input
	.Use<Frontmatter>()   // Extracts the file frontmatter into the metadata
	.Use<Markdown>()      // Renders Markdown files in input to HTML files in output
	.Use<FluidTemplate>() // Renders HTML files in output using specified Liquid templates in input
	.Build();             // Builds the website to the output directory
```

**4. See your completed website**

`index.html`:

```html
<html>
<head><title>Hello!</title></head>
<body>
<h1>Hello!</h1>
<p>Hello, World!</p>
</body>
</html>
```
