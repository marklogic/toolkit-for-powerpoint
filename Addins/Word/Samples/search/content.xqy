xquery version "1.0-ml";

(: $Id: content.xqy,v 1.3 2008-11-04 16:44:42 jmakeig Exp $ :)
import module namespace xp = "http://marklogic.com/xinclude/xpointer" at "/MarkLogic/xinclude/xpointer.xqy";
declare namespace w="http://schemas.openxmlformats.org/wordprocessingml/2006/main";

let $href := xdmp:url-decode(xdmp:get-request-field('uri'))
let $tokens := tokenize($href, "#")
let $uri := $tokens[1]
let $ptr := $tokens[2]
return (
	if(ends-with($uri, ".docx")) then (
			xdmp:set-response-content-type('application/vnd.openxmlformats-officedocument.wordprocessingml.document'),
			doc($uri)
	)	else (
		xdmp:set-response-content-type('application/xml'),
		if($ptr) then
			xp:dereference(doc($uri), $ptr)
		else 
			doc($uri)
	)
)
