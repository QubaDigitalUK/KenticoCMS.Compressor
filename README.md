# KenticoCMS.Compressor

This project provides automated image compression for images when uploaded (in .png or .jpg format) into a kentico media library. 
It uses pngcrush and jpegtran for the compression and works for media libraries stored on the local file system.


# Installation

1. Clone this repository into your project folder
2. Add KenticoCMS.Compressor.csproj to your solution file.
3. Add the following references to the KenticoCMS.Compressor.csproj.

- CMS.Core
- CMS.Dataengine
- CMS.MediaLibrary
- CMS.SiteProvider

4. In your cms project add a reference to KenticoCMS.Compressor and add the following to the web config:
 ~~~~
 <section name="cms.extensibility" type="CMS.Base.CMSExtensibilitySection, CMS.Base"/>
  ~~~~
 within the  <configSections> section and 
  
 ~~~~
   <cms.extensibility>
    <providers>
      <add name="MediaFileCompressionInfoProvider" assembly="KenticoCMS.Compressor" type="KenticoCMS.Compressor.MediaFileCompressionInfoProvider"/>
    </providers>
    <helpers/>
    <managers/>
  </cms.extensibility>
~~~~
   
 before the closing </configuration> element.

# License
This widget is provided under MIT license.

# Compatibility
This utlilty has been used on various Kentico 12 SP MVC and Portal Engine installations without issue.
 
 


