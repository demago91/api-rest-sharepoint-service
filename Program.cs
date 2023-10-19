// See https://aka.ms/new-console-template for more information
using Azure.Identity;
using LibSharepoint;
using LibSharepoint.Classes;
using Microsoft.Graph;
using Microsoft.Graph.Models;
using Microsoft.Graph.Security.Cases.EdiscoveryCases.Item.Custodians.Item.SiteSources.Item.Site;
using Microsoft.Kiota.Abstractions;
using Microsoft.Kiota.Abstractions.Serialization;
using Microsoft.Kiota.Abstractions.Store;
using System.Xml.Serialization;
// using Microsoft.IdentityModel.Clients.ActiveDirectory;
using System.Net.Http;
using System.Net.Http.Headers;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using ClientCredential = Microsoft.IdentityModel.Clients.ActiveDirectory.ClientCredential;
using AuthenticationResult = Microsoft.IdentityModel.Clients.ActiveDirectory.AuthenticationResult;
using Microsoft.Graph.Models.ExternalConnectors;

Console.WriteLine("Hello, Sharepoint Tests Service!");

#region Variables

var scopes = new[] { "sites.read.all" }; // , "User.Read"

// Values from app registration
var UserId = "bobnet@avocatparis.org";
var UserSecret = "9ypT9t+X513K0NPmf";

var SharePointUrl = "https://barreauparis.sharepoint.com/sites/share_URL/_api";
// https://barreauparis.sharepoint.com/sites/share_URL/_api/web/GetFolderByServerRelativeUrl('/sites/share_URL/Documents%20partages/DSI/Etudes/DEV/FCO')/Files

SharepointInfos infos = new()
{
    AppID = "4c94a47d-be66-40b6-89d7-229dc8a97cba",
    ClientSecret = "f8a8Q~PmEHAn30huH2e1inOydylDyEkhy9eUwbfb",
    TenantID = "67e40e13-7bf0-4032-b709-161b2f5b715b",
    SharePointUrl = "barreauparis.sharepoint.com",
    BaseWS = "https://barreauparis.sharepoint.com/sites/share_URL/_api/",
    BaseUrlAuth = "https://accounts.accesscontrol.windows.net/",
    Site = "shareURL",
    Path = "/sites/share_URL/Documents%20partages/DSI/Etudes/DEV/FCO"
};

var authorizationCode = infos.ClientSecret;

#endregion Variables

ServiceSharepoint _service = new();
_service.SetInformations(infos);


var tok = await _service.GetToken();
if (tok != null)
{
    Console.WriteLine("Token : " + tok.access_token);

    var retour = await _service.GetFiles(infos.Path);

    if(retour.EstOk)
    {
        Console.WriteLine("Fichiers Sharepoint : ");

    } else
    {
        Console.WriteLine("Erreur de récupération des fichiers");
        Console.WriteLine(retour.MessageErreur);
    }

} else
{
    Console.WriteLine("Erreur de récupération du Token d'authentification.");
}



/*
// using Azure.Identity;
var options = new AuthorizationCodeCredentialOptions
{
    AuthorityHost = AzureAuthorityHosts.AzurePublicCloud,
};


// https://learn.microsoft.com/dotnet/api/azure.identity.authorizationcodecredential
var authCodeCredential = new AuthorizationCodeCredential(
    infos.TenantID, UserId, UserSecret, authorizationCode, options);

var graphClient = new GraphServiceClient(authCodeCredential, scopes, SharePointUrl);

var driveItems = await graphClient.Sites["barreauparis.sharepoint.com,"+ infos.TenantID + ","+authorizationCode]
                             .Drives
                             
                             .GetAsync();
*/
/*
foreach (var items in driveItems)
{
    Console.WriteLine(items.Name);
}
*/
/* var graphClient = new GraphServiceClient(authCodeCredential, scopes, SharePointUrl);


try
{


    // Id App
    var result = await graphClient.Sites["0"].Lists["{list-id}"].Items.GetAsync((requestConfiguration) =>
    {
        requestConfiguration.QueryParameters.Expand = new string[] { "fields(select=Name)" };


    });

    if (result != null)
    {
        foreach(var item in result.Value)
        {
            Console.WriteLine(item);
        }
    }
} catch(Exception ex)
{

}
*/

/*
/ scopes: [
  //   'openid',
  //   'profile',
  //   'email',
  //   'allsites.fullcontrol',
  //   'allsites.manage',
  //   'allsites.read',
  //   'allsites.write',
  //   'sites.fullcontrol.all',
  //   'sites.manage.all',
  //   'sites.read.all',
  //   'sites.readwrite.all',
  //   'user.read',
  //   'user.read.all',
  // ], 
 */

/*
var scopes2 = new[] { "sites.read.all" }; // "https://graph.microsoft.com/.default"


// https://learn.microsoft.com/dotnet/api/azure.identity.clientsecretcredential
var clientSecretCredential = new ClientSecretCredential(
    tenantId, UserId, UserSecret, options);

var graphClient2 = new GraphServiceClient(clientSecretCredential, scopes2);

var site = graphClient2.Sites["0"];


try
{
    // Id App
    var result = await graphClient.Sites["0"].Lists["{list-id}"].Items.GetAsync((requestConfiguration) =>
    {
        requestConfiguration.QueryParameters.Expand = new string[] { "fields(select=Name)" };


    });

    if (result != null)
    {
        foreach (var item in result.Value)
        {
            Console.WriteLine(item);
        }
    }
}
catch (Exception ex)
{

}
*/






// https://barreauparis.sharepoint.com/sites/share_URL/_api/oauth2/v2.0/token
// https://barreauparis.sharepoint.com/sites/share_URL/_api/oauth2/v2.0/authorize
// https://barreauparis.sharepoint.com/sites/share_URL/_api/authorize
// https://barreauparis.sharepoint.com/sites/share_URL/_api/auth/oauth/token

// https://barreauparis.sharepoint.com/sites/share_URL/Documents%20partages/Forms/AllItems.aspx?ct=1693821345031&or=OWA%2DNT&cid=53de3d02%2D46a5%2Db804%2D7599%2D3cc43495e7d0&fromShare=true&ga=1&id=%2Fsites%2Fshare%5FURL%2FDocuments%20partages%2FDSI%2FEtudes&viewid=75236345%2D8831%2D4fa0%2D9406%2D3e85b921745f
// https://barreauparis.sharepoint.com/sites/share_URL/Documents%20partages/Forms/AllItems.aspx?ct=1693821345031&or=OWA%2DNT&cid=53de3d02%2D46a5%2Db804%2D7599%2D3cc43495e7d0&fromShare=true&ga=1&id=%2Fsites%2Fshare%5FURL%2FDocuments%20partages%2FDSI%2FEtudes%2Fformations%5Fco&viewid=75236345%2D8831%2D4fa0%2D9406%2D3e85b921745f
