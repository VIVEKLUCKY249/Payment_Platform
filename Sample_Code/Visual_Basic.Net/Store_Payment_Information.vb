' *
' * Bluepay VB.NET Sample code.
' *
' * This code sample runs a $0.00 AUTH transaction
' * against a customer using test payment information.
' * This stores the customer's payment information securely in
' * BluePay to be used for further transactions.
' * Note: THIS DOES NOT ENSURE THAT THE CREDIT CARD OR ACH
' * ACCOUNT IS VALID.
' *


Imports System
Imports BluePay.BPVB

Namespace BP10Emu

    Public Class Store_Payment_Information

        Public Sub New()
            MyBase.New()
        End Sub

        Public Shared Sub Main()

            Dim accountID As String = "MERCHANT'S ACCOUNT ID HERE"
            Dim secretKey As String = "MERCHANT'S SECRET KEY HERE"
            Dim mode As String = "TEST"

            ' Merchant's Account ID
            ' Merchant's Secret Key
            ' Transaction Mode: TEST (can also be LIVE)
            Dim payment As BluePayPayment_BP10Emu = New BluePayPayment_BP10Emu(
                    accountID,
                    secretKey,
                    mode)

            ' Card Number: 4111111111111111
            ' Card Expire: 12/15
            ' Card CVV2: 123
            payment.setCCInformation(
                    "4111111111111111",
                    "1215",
                    "123")

            ' First Name: Bob
            ' Last Name: Tester
            ' Address1: 123 Test St.
            ' Address2: Apt #500
            ' City: Testville
            ' State: IL
            ' Zip: 54321
            ' Country: USA
            payment.setCustomerInformation(
                    "Bob",
                    "Tester",
                    "123 Test St.",
                    "Apt #500",
                    "Testville",
                    "IL",
                    "54321",
                    "USA")

            ' Phone #: 123-123-1234
            payment.setPhone("1231231234")

            ' Email Address: test@bluepay.com
            payment.setEmail("test@bluepay.com")

            ' Auth Amount: $0.00
            payment.auth("0.00")

            payment.Process()

            ' Outputs response from BluePay gateway
            Console.Write("Transaction ID: " + payment.getTransID() + Environment.NewLine)
            Console.Write("Message: " + payment.getMessage() + Environment.NewLine)
            Console.Write("Status: " + payment.getStatus() + Environment.NewLine)
            Console.Write("AVS Result: " + payment.getAVS() + Environment.NewLine)
            Console.Write("CVV2 Result: " + payment.getCVV2() + Environment.NewLine)
            Console.Write("Masked Payment Account: " + payment.getMaskedPaymentAccount() + Environment.NewLine)
            Console.Write("Card Type: " + payment.getCardType() + Environment.NewLine)
            Console.Write("Authorization Code: " + payment.getAuthCode() + Environment.NewLine)
        End Sub
    End Class
End Namespace