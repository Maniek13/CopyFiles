CopyToCollectiveFolder

I make it for copy img file from folders, to restore deleted file.
I need this becouse aplication saves it in many similar folders. 

If someone need only 2 first arguments is important. But if you have 1milion folders with same fragment on name, you can put it in last value. 
(Plese set other args) 
This copy only from these folders to one you want. If files have same name, second and next one don't be copied and deleted. Copied files was deleted.

Copying files to a collective folder.

Aplication copy files from subfolders and optional from main folder to collective folder(no create subfolders). Duplicate files will not be copied.

Use:
Write below command in CMD with correct parameters


CopyFromSubFolders.exe" "mainFolderPath" "collectiveFolderPath" "useExtensionList" "deleteOtherFiles"  "copyFromMain" "subDirectoryNameContend"


Please set 0 or 1 to below settings:

"useExtensionList" 
"deleteOtherFiles"
"copyFromMain"


Default value:

useExtensionList: 0 
deleteOtherFiles: 0
copyFromMain: 1


Extension list can be modificated. It is in settings.xml
