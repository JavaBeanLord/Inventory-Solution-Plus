Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap

Module Inventory_Ebay_Module

    Public apiContext As ApiContext = GetApiContext()
    Public officialTime As DateTime

    Public Function timeCallToEbay()
        Dim apiCall As GeteBayOfficialTimeCall = New GeteBayOfficialTimeCall(apiContext)
        officialTime = apiCall.GeteBayOfficialTime()

        Return officialTime.ToString()
    End Function

    Private Function GetApiContext() As ApiContext
        apiContext = New ApiContext
        apiContext.SoapApiServerUrl = My.Settings.ApiServerUrl
        ' get token credential
        Dim apiCredential As ApiCredential = New ApiCredential
        apiCredential.eBayToken = My.Settings.apiToken
        apiContext.ApiCredential = apiCredential

        apiContext.Site = SiteCodeType.US

        Return apiContext
    End Function


End Module
