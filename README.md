# finaktiva-log-reader

--------------------------------------
## LIBRARIES

### FRONT-END
1) ANTD

### BACK-END
1) ENTITY FRAMEWORK
2) ENTITY FRAMEWORK SQL SERVER
3) ENTITY FRAMEWORK RELATIONAL
--------------------------------------
## MAIN BRANCH
1) NAME: MAIN
---------------------------------------
## CONECTION DATA BASE

* "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=EventLog;Connect Timeout=30;Trust Server Certificate=true;User=anderson;Password=anderson"
}
----------------------------------------
## ENDPOINTS
----------------------------------------
(CREATE A LOG)

* METHOD: POST
URL: http://localhost:5171/LogReader
BODY: (example)
{
    "Date": "2022-09-12",
    "Description": "qwe",
    "Event": 0
}
------------------------------------------
----------------------------------------
(GET LOGS)

* METHOD: GET
URL: http://localhost:5171/LogReader
------------------------------------------
