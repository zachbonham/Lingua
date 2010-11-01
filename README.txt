
About
-----
Lingua is a command line tool for helping manage string resource (*.resx) files for .NET.

Use Cases
---------

You want to add a resource file for your project.

**new-resource** 'MyResource'
 
Creates 'MyResource.en-us.resx'.  If the culture is not specified Lingua will use the default thread UI culture. 

**new-resource** 'MyResource' fr-fr

Creates 'MyResource.fr-fr.resx'

**add-resitem** 'MyResource' 'key' 'value'

Adds to the resource 'MyResource' the 'key' and 'value' pair.  If the 'key' value already exists, it will be updated.

**export-resource** 'MyResource'

exports all the name value pairs in the 'MyResource.*.resx' files to a comma seperated values (csv) list.  Cutlures can be split into 
seperate files.  e.g. if you have MyResource.en-us.resx and MyResource.fr-fr.resx then export-resource will produce two files by default:

1. MyResource.en-us.csv
2. MyResource.fr-fr.csv

Considering an option that will export to a single file with column for key and then an additional column per culture, like so:

key, en-us, fr-fr

