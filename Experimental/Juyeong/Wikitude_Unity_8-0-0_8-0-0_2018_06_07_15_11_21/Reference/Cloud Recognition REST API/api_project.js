define({  "name": "Wikitude Studio API",  "version": "3.0.0",  "description": "The RESTful API specification of the Wikitude Studio Manager",  "title": "Wikitude Studio API Reference",  "url": "",  "header": {    "title": "General Information",    "content": "<h3>API Structure</h3>\n<p>The API follows a RESTful API structure.</p>\n<p>Three HTTP Verbs are used in all requests:</p>\n<ul>\n<li><strong>GET</strong> - Lists existing Target Collections or Targets</li>\n<li><strong>POST</strong> - Creates new or manipulates existing Target Collections or Targets (<strong>PUT</strong> and <strong>PATCH</strong> are not used)</li>\n<li><strong>DELETE</strong> - Deletes Target Collection or Targets</li>\n</ul>\n<h3>Service Regions and Base URL</h3>\n<p>This service is available world-wide and hosted in Europe/Ireland. For cloud-recognition relevant endpoints, including the Target and Target Collection creation, you may also use the America Service. Note that Targets created in non-default regions are not replicated in Europe. E.g. A Target Collection created on Americas Service is <em>not</em> available in Europe.</p>\n<table>\n<thead>\n<tr>\n<th style=\"text-align:left\">Region</th>\n<th style=\"text-align:center\">Base URL for Manager API</th>\n</tr>\n</thead>\n<tbody>\n<tr>\n<td style=\"text-align:left\">Americas</td>\n<td style=\"text-align:center\"><code>https://api-us.wikitude.com/cloudrecognition</code></td>\n</tr>\n<tr>\n<td style=\"text-align:left\">Europe</td>\n<td style=\"text-align:center\"><code>https://api-eu.wikitude.com/cloudrecognition</code></td>\n</tr>\n</tbody>\n</table>\n<h2>General Response Structure</h2>\n<h3>Response Codes</h3>\n<p>The response code determines whether a request was successful. Any successful call will respond with code 200 (&quot;OK&quot;) or 204 (&quot;No content&quot;). In case of an error, a different response code is used, along with an error message (see below). Each API enpoint specifies the error types it may return.</p>\n<h3>Response</h3>\n<p>Three main kinds of JSON objects are used in the endpoints:</p>\n<ul>\n<li>An Image/Object <strong>Target</strong> or an Array of <strong>Targets</strong></li>\n<li>A Image/Object <strong>Target Collection</strong> or an Array of <strong>Target Collections</strong></li>\n<li>An <strong>Error</strong></li>\n</ul>\n<p>Each particular API specifies its response structure.</p>\n<h3>Image Target Collection</h3>\n<p>An Image <strong>TargetCollection</strong> contains the following properties:</p>\n<ul>\n<li><strong>id</strong> (String): An ID that uniquely identifies the Target Collection</li>\n<li><strong>name</strong> (String): The Name of the Target Collection, as defined by the user</li>\n<li><strong>creDat</strong> (Number): A timestamp when the Target Collection was created (as returned by JavaScript's <code>Date.now</code> function)</li>\n<li><strong>modDat</strong> (Number): A timestamp when the Target Collection was last modified</li>\n<li><strong>metadata</strong> (JSON): Arbitrary JSON data that is stored together with the TargetCollection.</li>\n<li><strong>wtc</strong> (Array): An array of wtc files that were generated out of the Target Collection already. Every element contains &quot;version&quot;, &quot;url&quot;, &quot;nrOfTargets&quot; and &quot;creDat&quot;. Only latest wtcFiles are stored, list is cleared on target modifications. Check &quot;Generate WTC File&quot; Endpoint for more details</li>\n</ul>\n<h3>Image Target</h3>\n<p>An <strong>Image Target</strong> contains the following properties:</p>\n<ul>\n<li><strong>id</strong> (String): An ID that uniquely identifies the Target</li>\n<li><strong>name</strong> (String): The Name of the Target, as defined by the user</li>\n<li><strong>imageUrl</strong> (String): The URL pointing to the original, uncompressed and uncropped Target binary file</li>\n<li><strong>thumbnailUrl</strong> (String): The URL pointing to a thumbnail representation of the Target</li>\n<li><strong>rating</strong> (Number): The rating (from 0 to 3) of the Target</li>\n<li><strong>fileSize</strong> (Number): The file size of the original Target binary image file in bytes</li>\n<li><strong>physicalHeight</strong> (Number): The physical (real world) height of the target. For more information check class CloudTracker of the <a href=\"http://www.wikitude.com/developer/documentation/android\">Wikitude SDK</a></li>\n<li><strong>creDat</strong> (Number): A timestamp when the Target was created</li>\n<li><strong>modDat</strong> (Number): A timestamp when the Target was last modified</li>\n<li><strong>metadata</strong> (JSON): Arbitrary JSON data that is stored together with the target.</li>\n</ul>\n<h3>Object Target Collection</h3>\n<p>An <strong>Object Target Collection</strong> contains the following properties:</p>\n<ul>\n<li><strong>id</strong> (String): An ID that uniquely identifies the Target Collection</li>\n<li><strong>name</strong> (String): The Name of the Target Collection, as defined by the user</li>\n<li><strong>creDat</strong> (Number): A timestamp when the Target Collection was created</li>\n<li><strong>modDat</strong> (Number): A timestamp when the Target Collection was last modified</li>\n<li><strong>metadata</strong> (JSON): Arbitrary JSON data that is stored together with the TargetCollection.</li>\n<li><strong>wto</strong> (Array): An array of wto files that were generated out of the Target Collection already. Every element contains &quot;version&quot;, &quot;url&quot;, &quot;nrOfTargets&quot; and &quot;creDat&quot;. Only latest wtcFiles are stored, list is cleared on target modifications. Check &quot;Generate WTO File&quot; Endpoint for more details</li>\n</ul>\n<h3>Object Target</h3>\n<p>An <strong>Object Target</strong> contains the following properties:</p>\n<ul>\n<li><strong>id</strong> (String): An ID that uniquely identifies the Target</li>\n<li><strong>name</strong> (String): The Name of the Target, as defined by the user</li>\n<li><strong>resource</strong> (JSON): Contains attributes <strong>uri</strong> and <strong>fov</strong>, the URL to the video assets and the video's field of view.</li>\n<li><strong>thumbnailUrl</strong> (String): The URL pointing to a thumbnail representation of the Target</li>\n<li><strong>rating</strong> (Number): The rating (from 0 to 3) of the Target</li>\n<li><strong>creDat</strong> (Number): A timestamp when the Target was created (as returned by JavaScript's <code>Date.now()</code> function)</li>\n<li><strong>modDat</strong> (Number): A timestamp when the Target was last modified (as returned by JavaScript's <code>Date.now</code> function)</li>\n</ul>\n<h3>Error</h3>\n<p>In case the server cannot serve the request successfully, it responds with an error object, consistaining of the following properties:</p>\n<ul>\n<li><strong>code</strong> (Number): An internal error code that further specifies the error (currently, we copy the response code from the HTTP response in here, but we might want to change this in the future)</li>\n<li><strong>reason</strong> (String): A short title that tells the developer what has gone wrong</li>\n<li><strong>message</strong> (String): A more detailed explanation of what has gone wrong, and what needs to be done to prevent the error.</li>\n<li><strong>cause</strong> (JSON): The exact cause of the error</li>\n<li><strong>moreInfo</strong> (String): Optional more information how to resolve the error</li>\n</ul>\n<h4>Example</h4>\n<pre><code>{\n &quot;code&quot;: 400,\n &quot;reason&quot;: &quot;HEADER_PROPERTY_MISSING&quot;,\n &quot;message&quot;: &quot;One or more mandatory header properties are missing.&quot;,\n &quot;cause&quot;: [\n    {\n        &quot;item&quot;: &quot;X-Token&quot;,\n        &quot;value&quot;: &quot;&quot;\n    }\n ],\n &quot;moreInfo&quot;: &quot;http://www.wikitude.com/developer/documentation/cloud&quot;\n}\n</code></pre>\n"  },  "sampleUrl": false,  "defaultVersion": "0.0.0",  "apidoc": "0.3.0",  "generator": {    "name": "apidoc",    "time": "2018-02-21T09:57:17.270Z",    "url": "http://apidocjs.com",    "version": "0.17.6"  }});
