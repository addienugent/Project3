<?xml version="1.0" encoding="UTF-8" ?>
<ContentPage
    xmlns="http://xamarin.com/schemas/2014/forms"
    xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
    x:Class="EcommerceAppMobile.Pages.EditProductW">
    <ContentPage.Content>

       <StackLayout>

           <Label Text="Adjust Product in Inventory" HorizontalTextAlignment="Center" FontSize="25"/>
            <Label x:Name="prodName" HorizontalTextAlignment="center" FontSize="30"/>

            <Label x:Name="prodPrice" HorizontalTextAlignment="center" FontSize="25"/>
            <Label x:Name="prodWeight" HorizontalTextAlignment="center" FontSize="20"/>
            <Label x:Name="prodDescription" HorizontalTextAlignment="center" FontSize="20"/>
            <Label x:Name="sliderCart" FontSize="25" HorizontalTextAlignment="Center"/>


           <Button Text="Back"
                     x:Name="backCartButton"
                     Clicked="Back_Clicked"/>
        </StackLayout>
    </ContentPage.Content>
</ContentPage>

