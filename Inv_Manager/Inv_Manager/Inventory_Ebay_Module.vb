Imports eBay.Service.Call
Imports eBay.Service.Core.Sdk
Imports eBay.Service.Core.Soap
Imports eBay.Service.Util

Module Inventory_Ebay_Module

    Public apiContext As ApiContext = GetApiContext()

    Public Sub addItemCall()
        Try
            Dim item As ItemType = BuildItem()
            Dim apiCall As AddItemCall = New AddItemCall(apiContext)
            Dim fees As FeeTypeCollection = apiCall.AddItem(item)
            Dim listingFee As Double = 0.0
            Dim fee As FeeType
            For Each fee In fees
                If (fee.Name = "ListingFee") Then
                    listingFee = fee.Fee.Value
                End If
            Next
            ' show listing and item id
            MsgBox("Listing Fee: " & listingFee & " Item ID: " & item.ItemID)
        Catch ex As Exception
            MsgBox("Error: Could not list item.")
        End Try
    End Sub

    Private Function BuildItem() As ItemType
        Dim item As ItemType = New ItemType()

        item.Title = "Dell Latitude"
        item.Description = "This is a test item."
        item.ListingType = ListingTypeCodeType.Chinese
        item.Currency = CurrencyCodeType.USD
        item.StartPrice = New AmountType()
        item.StartPrice.Value = 20
        item.StartPrice.currencyID = CurrencyCodeType.USD
        item.ListingDuration = "Days_5"
        item.Location = "Smithfield"
        item.Country = CountryCodeType.US

        Dim category As CategoryType = New CategoryType()

        category.CategoryID = "162922"
        item.PrimaryCategory = category
        item.Quantity = 1
        item.PaymentMethods = New BuyerPaymentMethodCodeTypeCollection()
        item.PaymentMethods.Add(BuyerPaymentMethodCodeType.PayPal)
        item.PayPalEmailAddress = "email@email.com"
        item.ConditionID = 1000
        item.ItemSpecifics = BuildItemSpecifics()
        item.DispatchTimeMax = 1
        item.ShippingDetails = BuildShippingDetails()
        item.ReturnPolicy = New ReturnPolicyType()
        item.ReturnPolicy.ReturnsAcceptedOption = "ReturnsAccepted"

        Return item
    End Function

    Private Function BuildShippingDetails() As ShippingDetailsType
        Dim shippingDetails As ShippingDetailsType = New ShippingDetailsType()
        Dim amount As AmountType = New AmountType()
        Dim shippingOptions As ShippingServiceOptionsType = New ShippingServiceOptionsType()

        shippingDetails.ApplyShippingDiscount = True
        amount.Value = 5
        amount.currencyID = CurrencyCodeType.USD
        shippingDetails.PaymentInstructions = "Payment instructions go here."

        shippingDetails.ShippingType = ShippingTypeCodeType.Flat
        shippingOptions.ShippingService = _
            ShippingServiceCodeType.ShippingMethodStandard.ToString()
        amount = New AmountType()
        amount.Value = 2.0
        amount.currencyID = CurrencyCodeType.USD
        shippingOptions.ShippingServiceAdditionalCost = amount
        amount = New AmountType()
        amount.Value = 10
        amount.currencyID = CurrencyCodeType.USD
        shippingOptions.ShippingServiceCost = amount
        shippingOptions.ShippingServicePriority = 1
        amount = New AmountType()
        amount.Value = 1.0
        amount.currencyID = CurrencyCodeType.USD
        shippingOptions.ShippingInsuranceCost = amount

        shippingDetails.ShippingServiceOptions = New ShippingServiceOptionsTypeCollection()
        shippingDetails.ShippingServiceOptions.Add(shippingOptions)

        Return shippingDetails
    End Function

    Private Function BuildItemSpecifics() As NameValueListTypeCollection
        Dim nvCollection As NameValueListTypeCollection = New NameValueListTypeCollection()
        Dim nameValueListType1 As NameValueListType = New NameValueListType()
        Dim nameValueListType2 As NameValueListType = New NameValueListType()
        Dim nameValueCollection1 As StringCollection = New StringCollection()
        Dim nameValueCollection2 As StringCollection = New StringCollection()
        ' the names of each list
        nameValueListType1.Name = "Hardware"
        nameValueListType2.Name = "OS"
        ' items to be added to collection
        Dim stringArray1() As String = {"Computer"}
        Dim stringArray2() As String = {"Windows"}
        ' adding arrays of values to collections
        nameValueCollection1.AddRange(stringArray1)
        nameValueCollection2.AddRange(stringArray2)
        ' consolidates lists/collections
        nameValueListType1.Value = nameValueCollection1
        nameValueListType2.Value = nameValueCollection2
        nvCollection.Add(nameValueListType1)
        nvCollection.Add(nameValueListType2)

        Return nvCollection
    End Function

    Public Function timeCall()
        Dim apiCall As GeteBayOfficialTimeCall = New GeteBayOfficialTimeCall(apiContext)
        Dim officialTime As DateTime = apiCall.GeteBayOfficialTime()

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
