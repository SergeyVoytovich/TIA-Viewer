# TIA-Viewer
Test task to demonstrate skills on 01.10.2021


## General
With the help of a "* .tia" file, the user of the TIA Selection Tool (http://www.siemens.com/tia-selection-tool) is able to persist the configuration carried out in the local file system. This file contains both business and application information in an XML format. The business structure corresponds to a graph with nodes (<node Type = "...">) and edges (<edge Type = "...">).
  
## Task description
The task is to interpret a "* .tia" file and to process the data for further processing. A screen mockup of the application is present.
  
After selecting a "* .tia" file, the user can select an element from a selection list at the top between the individual node types (note: only include elements that have the XML attribute "Type =" ... ""). The corresponding individual elements are then visualized by name in the middle of the GUI based on the selected type.
  
The other buttons should be displayed, but currently do not have any functionality.
  
## Technology Stack
The application must be written in C # using WPF for UI
  
## Additional
The application must have modern and attractive design
