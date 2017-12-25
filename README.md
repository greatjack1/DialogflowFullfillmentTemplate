## Dialog Flow Fulfillment Template

This project is a complete working web api implementation of a Dialog Flow fulfillment service. It can be used as a template to easily build fulfillment services for Dialog Flow in .net core and c#

## Architecture

The Architecture used is MVC just without the views. This is due to the fact that all responses are just serialized models and making seperate views just to stick to MVC is overkill for a template.


## Motivation

The motivation for this project was from the fact that google is pushing firebase as a backend for Dialog Flow/Actions on Google, and I felt us .net devs should have a good alternative.

## Usage

This template contains two controllers, one testing and one production. The template binds the post request data into a poco so that you don't have to deal with any json at all. Just put your code in the Post method of a controller that returns a the json of a JsonResponse object from the models, and you are good. In fact the template actually has a default implementation of the post method that returns a the json of a JsonResponse object, so you can use that to learn how to return the proper json.

## Hosting

I highly recommend hosting your fulfillment service on heroku. Just use the .net core build pack from jcod.

## Contributors

The template was solely designed and implemented by Yaakov from the WYRE corp

## Contact

To contact the developer with question, comments or anything else, just send a email to steeltoejava at gmail.com (The @ symbol is ommited to prevent spam scrapers)
