# MangoShop
A simple Unturned economy plugin using chat line without Database. The currency of this plugin is xp of players.
## How to develop
[Download dotnetSDK](https://dotnet.microsoft.com/en-us/download) to enable "dotnet" command on terminal  
[Download .NET Framework 4.6.1](https://www.microsoft.com/en-us/download/details.aspx?id=49978) then install to compile the plugin into correct version which fits Unturned Server  
Use "dotnet build" command on terminal to pack the plugin into a .dll file  

## How to use the plugin
There are 3 commands: /check, /buy and /sell. These commands are meant to be used by everyone that has permissions for them. Remember to put the command in the permissions file.  

Usage:  
- /check \<name\> [amount]
    - The argument _name_ is necessary and argument _amount_ is optional, default is 1.
    - This will evaluate the same name product configured in xml file, prompt the price when player purchasing
- /buy \<name\> [amount]
    - The argument _name_ is necessary and argument _amount_ is optional, default is 1.
    - This will cost xp of the player then give the specified product according to the name. The product will be regarded as _DefaultMetaItemProduct_ or _DefaultMetaVehicleProduct_ if there's no name matched in xml file.
- /sell \<name\> [amount]
    - The argument _name_ is necessary and argument _amount_ is optional, default is 1.
    - This will give xp back to the player then remove the specified product according to the name. The product will be regarded as _DefaultMetaItemProduct_ or _DefaultMetaVehicleProduct_ if there's no name matched in xml file.

### Examples
Help of Buy: `/buy help`  
Buy a bag of chips: `/buy i.82`  
Buy ten bags of chips: `/buy i.82 10`  
Buy a bicycle: `/buy v.185`  
Buy lottery: `/buy lottery`  

Help of Sell: `/sell help`  
Sell two bag of chips: `/sell i.82 2`  

Help of price checking: `/check help`  
Check price of a bag of chips: `/check i.82`  
Check price of five axes: `/check i.16 5`  
Check price of a bicycle: `/check v.185`  

## Terms
- MetaProduct: The basic description to generate a real product
- ProductType: The string for dispatcher to determine which type of product should be generated
- ProductName: The keyword to match user's input
- BasePrice: The price in default without float price
- Elasticity: Price increment when the specific product has been purchased
- Scarcity: Times that the specific product has been purchased, and it'll be reduced when the product is sold by the player