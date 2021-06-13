Price calculation exercise
Create a customer basket that allows a customer to add products and provides a total cost of the basket including applicable discounts.

Available products

Product Cost

Butter £0.80

Milk £1.15

Bread £1.00


Offers
• Buy 2 Butter and get a Bread at 50% off

• Buy 3 Milk and get the 4th milk for free

Scenarios
• Given the basket has 1 bread, 1 butter and 1 milk when I total the basket then the total should be £2.95

• Given the basket has 2 butter and 2 bread when I total the basket then the total should be £3.10

• Given the basket has 4 milk when I total the basket then the total should be £3.45

• Given the basket has 2 butter, 1 bread and 8 milk when I total the basket then the total should be £9.00


Solution

First i thought to implement this with Decorator pattern but after more analysis I found strategy pattern with rule engine will be more effective to this issue and will fit in solid principals, I used factory pattern earlier but removed as can be done without.
S : Every Service has its own implementation based on usage
O : We don't need to make any changes to add more strategies, just inhareit Base Discount Strategy and implement our discount logic and plugin with basket, So by this Single use
L : Inheritence used top to bottom
I : interfaces used properly
D : Dependency inversion with loosly couples classes

I read this articles to understand something and then designed whole system based on my understanding
http://codekata.com/kata/kata09-back-to-the-checkout/

