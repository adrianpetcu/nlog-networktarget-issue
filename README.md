# nlog-networktarget-issue

There seems to be an issue when logging only to the network target, with JsonLayout: the fields obtained through the  event-properties renderer are missing. To reproduce:

1. Start a TCP listener. Within the project, a node.js one is provided. Start it with:

node listener.js

2. Run the console with both targets enabled - file and network (writeTo="fileTarget,networkTarget"). The message logged by the listener should look like:

{ application: 'NLogConsole',
  timestamp: '2018-02-12T09:12:42.7514494Z',
  machineName: 'LAB-01',
  environment: 'DEV',
  dbResponseTime: 50,
  messagesSentTotal: 100,
  module: 'core' }

3. Leave the listener open. Change Nlog.config to log only to the network target (writeTo="networkTarget") and start the console again. The message received by the listener will not contain the dbResponseTime and messagesSentTotal (layout for event-properties:item):

{ application: 'NLogConsole',
  timestamp: '2018-02-12T09:13:06.8305696Z',
  machineName: 'LAB-01',
  environment: 'DEV',
  module: 'core' }



