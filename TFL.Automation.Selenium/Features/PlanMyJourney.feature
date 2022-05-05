Feature: PlanMyJourney
In order to plan a Journey, as a SDET i should be able search for all the different journey options available and perform business logic validations.

@JourneyPlan
Scenario Outline: Show that I can plan a Journey with valid locations
	Given I have Launched TFL website
	And I have provided valid from "<From>" and to "<To>" locations
	When I click on plan my Journey
	Then results with journey options should be displayed "<From>"/"<To>"

	Examples:
		| From     | To      |
		| IG11 7PY | IG6 2UH |

@JourneyPlan
Scenario Outline: Show that I can not see results for invalid locations
	Given I have Launched TFL website
	And I have provided valid from "<From>" and to "<To>" locations
	When I click on plan my Journey
	Then results are not displayed

	Examples:
		| From     | To      |
		| IG6 2UH  | E14 2UH |

@JourneyPlan
Scenario Outline: Show that I can not plan journey without valid locations
	Given I have Launched TFL website
	And I have provided valid from "<From>" and to "<To>" locations
	When I click on plan my Journey
	Then "<FromValidation>"/"<ToValidation>" message should be displayed for the respective fields

	Examples:
		| Scenario            | From    | To      | FromValidation | ToValidation |
		| Empty From Location |         | IG6 2UH | true           | false        |
		| Empty To Location   | IG6 2UH |         | false          | true         |
		| Empty From and To   |         |         | true           | true         |

@JourneyPlan
Scenario Outline: Show that I can edit a Journey from the results
	Given I have Launched TFL website
	And I have provided valid from "<From>" and to "<To>" locations
	When I click on plan my Journey
	Then results with journey options should be displayed "<From>"/"<To>"
	And I can edit the journey and get updated results

	Examples:
		| From     | To      |
		| IG11 7PY | IG6 2UH |

@JourneyPlan
Scenario: Show that I can view my Recent Journey details
	Given I have Launched TFL website
	When I click on Recents
	Then I can view my recent journey details

