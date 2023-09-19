//Environment
Visual Studio 2019 in Mac Os
.net 7.0
Unit testing with NUnit

//Folder Structure
- Car Simulation - main Folder
    -   SimulatorApp => main Project folder
            -   Various Subfolders ddepends on the responsblity- Which can move to libs if needed
    -   Unit Test Project   

//Class Diagram for reference 
Please refer ClassDiagram.jpg


//Working
    InputHandler
        -   Helper class to handle user inputs and parsing

    AutoDriver is the main driver class hre which will create
        -   the simualtionField
        -   Car using CarFactory
        -   Create SimualtorWrapper with car and commands
   AutoDriver will execute simulation
        -   send commands to each simualtor one by one
        -   Simualtor will exeute the top command in the queue
        -   Any collision it will inform auto driver and autodriver in turn will update other simulators which happen to be in the same location