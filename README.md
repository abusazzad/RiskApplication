# RiskApplication
Bet risk analysis application

The solution needs to be opened in either VS2015 or VS2013. 
The supported .NET version is 4.6.1
Nuget packages need to be restored before compiling. 

Run the solution.

Send the following HTTP GET requests:
<ol>
<li>To get a list of all settled bets: http://localhost:9483/api/SettledBetQuery <br/>
<pre> 
[
  {
    "winAmount": 250,
    "customerId": 1,
    "eventId": 1,
    "participantId": 6,
    "stake": 50,
    "id": 1
  },
  {
    "winAmount": 0,
    "customerId": 2,
    "eventId": 1,
    "participantId": 3,
    "stake": 5,
    "id": 2
  },
]
</pre>
</li>
<li>To get a list of all settled bets including status (Risky) of a particular customer: http://localhost:9483/api/SettledBetQuery?CustomerId=1 
<pre>
{
  "bets": [
    {
      "winAmount": 250,
      "customerId": 1,
      "eventId": 1,
      "participantId": 6,
      "stake": 50,
      "id": 1
    },
    {
      "winAmount": 60,
      "customerId": 1,
      "eventId": 2,
      "participantId": 1,
      "stake": 20,
      "id": 5
    },
  ],
  "riskType": "Risky"
}
</pre>
</li>
<li>To get a list of all unsettled bets with predicted risk type: http://localhost:9483/api/UnsettledBetQuery
<pre>
[
  {
    "riskType": "Risky",
    "toWinAmount": 500,
    "customerId": 1,
    "eventId": 11,
    "participantId": 4,
    "stake": 50,
    "id": 1
  },
  {
    "riskType": "None",
    "toWinAmount": 400,
    "customerId": 3,
    "eventId": 11,
    "participantId": 6,
    "stake": 50,
    "id": 2
  },
  {
    "riskType": "WIN 1K+",
    "toWinAmount": 1200,
    "customerId": 4,
    "eventId": 11,
    "participantId": 7,
    "stake": 300,
    "id": 3
  },  
]
</pre>
</li>
</ol>
