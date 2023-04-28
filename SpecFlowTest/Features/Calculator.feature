Feature: Calculator
![Calculator](https://specflow.org/wp-content/uploads/2020/09/calculator.png)
Simple calculator for adding **two** numbers

Link to a feature: [Calculator](SpecFlowTest/Features/Calculator.feature)
***Further read***: **[Learn more about how to generate Living Documentation](https://docs.specflow.org/projects/specflow-livingdoc/en/latest/LivingDocGenerator/Generating-Documentation.html)**

@mytag
Scenario: Check if points given to the player are eqaul to the value of 3 similar dice multipled by 2 
	Given list of dice with value 1,4,4,4,5,6
	When the value of 3 dice are equal 
	Then the points earned should be 400

