# SFTPFileUploadUsingWebAPIandAngularJS
Uplaod files to SFTP using ASp.NET Web API and AngularJS upload plugin by nervgh

Angular-file-upload directive by nervgh is an awesome lightweight AngularJS directive which handles file upload for you and lets you upload files asynchronously to the server. This post will give you basic understanding on how to upload files by using this directive together with .NET WebAPI service on SFTP server. For the purpose of this tutorial, I'll keep everything as simple as possible since the focus here is on connecting AngularJS and async upload with a .NET WebAPI service and not on additional functionality which can be built afterwards around angular-file-upload.

1. extensionFilter is used to allow only pdf, doc, docx and rtf documents
2. File size limit is also implemented by allowing file upto 5 MB
3. Number of files allowed in upload queue is also implemented by filter.
4. In WebAPI, UploadedDocuments folder is created to get file into webserver from client.
5. Drag and drop is also implemented along with default browse button.
