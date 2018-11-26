# Metalsharp.FluidTemplate

A [Metalsharp plugin](https://github.com/IanWold/Metalsharp) using [Fluid](https://github.com/sebastienros/fluid) to let you define [Liquid templates](https://shopify.github.io/liquid/).

## How it works

**1. Create your Liquid template file and include it in your Metalsharp project directory**

Here's an example template called `/Site/layout.template`:

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

Let's assume our project directory also contains `/Site/index.md`. Here's how to specify the layout in the frontmatter:

```md
---
title: "Hello!"
layout: "layout.template"
---
Hello, World!
```

**3. Use `FluidTemplate` in your Metalsharp plugin stack**

```c#
new MetalsharpDirectory("Site")    // Reads the files in the directory `/Site/` to input
    .Use<Frontmatter>()   // Extracts the file frontmatter into the metadata
    .Use<Markdown>()      // Renders Markdown files in input to HTML files in output
    .Use<FluidTemplate>() // Renders HTML files in output using specified Liquid templates in input
    .Build();             // Builds the website to the output directory
```

**4. See your completed website**

`/bin/index.html`:

```html
<html>
<head><title>Hello!</title></head>
<body>
<h1>Hello!</h1>
<p>Hello, World!</p>
</body>
</html>
```

## Fluid License

*This is the license for [Fluid](https://github.com/sebastienros/fluid), a major component of this project*

MIT License

Copyright (c) 2017 Sébastien Ros

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
