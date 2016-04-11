# BootEasy Client Bundling for Umbraco

## Introduction

This is a addon for the [BootEasy for Umbraco framework](https://github.com/dawoe/umbraco-booteasy) that will allow easy bundling and minifaction of client side assets like css and javascript using the [Microsoft Asp.NET optimization framework](https://www.nuget.org/packages/Microsoft.AspNet.Web.Optimization/)

The package will allow configuration of your style and script files using a config file instead of coding it in a application start event.

## Usage

### Configuration

After you have installed the package using nuget or the Umbraco package installer you will have a new file in the Config folder of your Umbraco install called BootEasyClientBundling.config

```XML
<?xml version="1.0" encoding="utf-8"?>
<BootEasyClientBundling>
	<CssBundles>
    <!--
		<bundle name="Example css bundle" path="~/bundles/css/examplecss.css">
			<files>
				<file path="~/assets/css/bootstrap.css" />
				<file path="~/assets/css/style.css" />				
			</files>
		</bundle>
    -->
	</CssBundles>
	<ScriptBundles>
    <!-- 
		<bundle name="Example scripts bundle" path="~/bundles/scripts/examplescripts.js">
			<files>
				<file path="~/assets/js/jquery.js" />
				<file path="~/assets/js/jquery.validate.js" />
				<file path="~/assets/js/jquery.validate.unobtrusive.js" />				
				<file path="~/assets/js/scripts.js" />				
			</files>
		</bundle>
    -->
	</ScriptBundles>
</BootEasyClientBundling>
```

We have 2 sections where we set up bundles, the CssBundles and the ScriptBundles sections.

For each bundle you must define 2 attributes :

- name : the name of the bundle
- path : the path used to render the bundle

For each bundle you can add multiple files to the file collection. You must define the path property of the file you want to include in the bundle

### Rendering

After you have configured the bundles using the config file you can render them in the template like this :

```C#
@Styles.Render("~/bundles/css/examplecss.css")
@Scripts.Render("~/bundles/scripts/examplescripts.js"),
```