Using an example of making an API call to Moz which asks what is the domain authority of comparethemarket.com.

Since an API is basically just a website. A website which contains just data, presented usually as JSON, and no html, CSS or java-script. Then to call MOZ's API and ask if for the domain authority of comparethemarket.com, we have to make up a URL string. 

A completed url looks like this; (login details have been slightly altered)

https://lsapi.seomoz.com/linkscape/url-metrics/comparethemarket.com?Cols=68719476736&Limit=10&AccessID=member-mozscape-45676fedfgg11918&Expires=1519988622&Signature=dg%2bWtcTbVBg%2fQmtAIwcloy2S7aY%3d



This has been put together by the following steps: 



The HTTP or HTTPS request to the host name and resource.
http://lsapi.seomoz.com/linkscape/

2. The API command to call.

http://lsapi.seomoz.com/linkscape/url-metrics/

3. The target URL to analyze(in this case comparethemarket.com) .

http://lsapi.seomoz.com/linkscape/url-metrics/comparethemarket.com

4. The parameters to call. The ? indicates where the parameters begin. The & seperates each paramter. The 'Cols=' then the number is the reference to which paramter you are querying (in this example domain authority which has been given the code 68719476736, the 'Cols=' is always before the number no matter which paramaters/ information you want to find out).



https://lsapi.seomoz.com/linkscape/url-metrics/comparethemarket.com?Cols=68719476736&Limit=10&

(The limit relates to the amount of decimal places you get back in the response for the domain authority).



5. Paste this url into your browser. A pop up is generated which asks for your authetication information. 

Fill this in with (slightly altered):



Access ID:

mozscape-4726a22918



Secret Key:

5dd5adca2d11b02fc2ce94657b1db23c



You can generate your access ID and secret key here:

https://moz.com/products/api/keys



Free access allows for one request every ten seconds, up to 25,000 rows per month



What your browser is doing here is generating an 'encripted authentication' string, a signature which is added to the end of the rest of the url. The completed url looks like;

https://lsapi.seomoz.com/linkscape/url-metrics/comparethemarket.com?Cols=68719476736&Limit=10&AccessID=member-mozscape-45676fedfgg11918&Expires=1519988622&Signature=dg%2bWtcTbVBg%2fQmtAIwcloy2S7aY%3d



6. To call this url with a prgamme, ie the SEO Dashboard, Then this end authetication signature needs to be encoded by your programme.



This signed authentication has 3 query string paramters to every call:

AccessID 
Expires (UNIX timestamp in seconds) - how long the request is valid for .. should only be a few mins ahead of current time.
Signature - an HMAC-SHA1 hash of your Access ID, the Expires parameter, and your Secret Key. The secure hash must be base64 encoded then URL-encoded before Mozscape accepts the signature as valid.
The final authetication string, which should be added to the end of the API call url should look like this:

AccessID=member-cf180f7081&Expires=1225138899&Signature=LmXYcPqc%2BkapNKzHzYz2BI4SXfC%3D



What does 3 mean?



3 relates to the 

"&Signature="... part at the end of the url call, the letters and numbers which come after it are created by the following process:



Create a HMAC hash from the 3 described paramaters (Access ID, Expires parameter, and Secret Key).


Access ID ==> HMAC-SHA1 String 

The HMAC is a hash based method which takes some information, say a word, and character by character changes this inot hexidecimal numbers. 

The SHA1 is the specific algorithm which is used to create the HMAC hash.

An example of a HMAC-SHA1 hash is;

a298f932c163f3abf36c324f1e252e81eec577ea

This is basically a string of hexidecimal characters.

(Generated using; https://www.freeformatter.com/hmac-generator.html).



2.  Then we convert this Hexidecimal string to a base64 one. 



Hexadecimal string ==> base64 string

A Hex is a base16 string. Base64 is shorter but has a much larger number of letters and characters which represent it. 

An example of a base64 string is:

0kDaABnU4R+J6OiCjezSk5Io8vw=

(Generated using; http://tomeko.net/online_tools/hex_to_base64.php?lang=en).



3. Convert this base64 string to a url encoded string.

Base64 string ==> URL encrypted string 

A base64 string can include characters which are not supported in a url. Since the encoded string generated needs to be posted in the url the last step is to url encrypt it. 

An example of a url encoded string is:

0kDaABnU4R%2BJ6OiCjezSk5Io8vw%3D

Characters such as = cannot go in a url so this step has encoded these unsupported characters.

(Generated using; https://ostermiller.org/calc/encode.html).





How to add the authentication signature:

https://github.com/abitravers1989/autheticationSpike

(This first creates the encrypted signature string, then appends this to a string with the AccessID and Expires details on. This string will then be appended to the end of the API call which has been put together above.



Why has this been done by Moz?

This has been done because Moz's database will most likely hold an encryption of your access ID and  Secrete Key. They will have done the same steps (potentially bar the url encryption) once they generated your account information. This means they aren't holding in their database (which can be seen by the engineers working for them or potentially someone who hacked in to get access), they are holding an encoded version of it. So someone would not be able to know your information if they got hold of the database which contains it. 

This is an example of a one-way encryption.



The orignial spike:

https://github.com/ComparetheMarket/MIT.SEOAggregator




How the information is fed back to us, and what format
For domain authority call to moneysupermarket.com:

{"pda":72.84861274375207}