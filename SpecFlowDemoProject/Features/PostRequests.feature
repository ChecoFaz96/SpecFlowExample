Feature: Post Requests

A short summary of the feature

@PostMethod
Scenario: Add a new post to the API
	Given the API is available at "http://localhost:3000/"
	When I send a POST request to "posts" with the following details
		| id | title               | views |
		| 6  | Asynchronous Course | 600   |
	Then the response should contain:
	| id | title               | views |
	| 6  | Asynchronous Course | 600   |


Scenario: Validate title of  a new post to the API
Given the API is available at "http://localhost:3000/"
When I send a POST request to "posts" with the following details
	| id | title               | views |
	| 3  | Asynchronous Course | 300   |
Then the title should be: "Asynchronous Course"

	
	