# Hex Patcher Demo

![GitHub](https://img.shields.io/github/license/StevenJDH/Hex-Patcher-Demo)

This very basic application demonstrates one approach that can be used to patch a file. You will need to know the path of the file, the offset to the byte you want to patch, the byte that is currently there, and the new byte you watch to use in its place. For my tests, I used the free hex editor XVI32, which you can find here [http://www.chmaas.handshake.de/delphi/freeware/xvi32/xvi32.htm#download](http://www.chmaas.handshake.de/delphi/freeware/xvi32/xvi32.htm#download) in the download section. If you need to patch multiple files with the same new byte, but who have different offsets, then dynamically acquiring the offset using a pattern search would probably be more efficient.

## The Offset
The offset of the byte can be found somewhere on the hex editor you are using. For XVI32, it is at the bottom left of the window. You will need to know what you are looking for to be able to determine the offset. For example, searching for a particular pattern as you see people doing on this Gist [https://gist.github.com/t2t-sonbui/8aaa336dcf988ef282b1e5f7afc3238e](https://gist.github.com/t2t-sonbui/8aaa336dcf988ef282b1e5f7afc3238e). 

## The Byte
The code is using hard-coded hex literals defined by the 0x flag in front of the value. The compiler will convert these values to their decimal equivalents before using them. For example, the hex value 15 is 21 in decimal, which is what is stored in the primitive types as you can see when debugging. Your hex editor will probably favor the hex values, so it is easier to work with them, but it may also show their decimal equivalents. Either base number system is fine as long as you don't mix them up.

If you are using XVI32, you can go to the 'Tools' menu and select 'Bit manipulation...' to see what bits are set to on for the byte you want to change. For example, the hex value 15 will look like this:

7|6|5|4|3|2|1|0
-|-|-|-|-|-|-|-
0|0|0|1|0|1|0|1

The top row represents the 8 bit positions in a byte counting from right to left and starting from 0. The bottom row represents our base 2 binary system that evaluates to 15 based on which bits are set to on. You can manually swap bit positions 0 and 1 to get the hex value 16 as so:

7|6|5|4|3|2|1|0
-|-|-|-|-|-|-|-
0|0|0|1|0|1|1|0

When we write our new byte to the specified offset, we are essentially overwriting these 8 bits in the byte. From there, whatever the patching was supposed to achieve will happen correctly unless the incorrect information was supplied.

## DISCLAIMER
There are many legit uses for this code, and therefore, I am providing it for educational purposes only since many people online were looking for it without any luck. I will not be held responsible for any illegal uses of it.

## Want to show your support?

|Method       | Address                                                                                                    |
|------------:|:-----------------------------------------------------------------------------------------------------------|
|PayPal:      | [https://www.paypal.me/stevenjdh](https://www.paypal.me/stevenjdh "Steven's Paypal Page")                  |
|Bitcoin:     | 3GyeQvN6imXEHVcdwrZwKHLZNGdnXeDfw2                                                                         |
|Litecoin:    | MAJtR4ccdyUQtiiBpg9PwF2AZ6Xbk5ioLm                                                                         |
|Ethereum:    | 0xa62b53c1d49f9C481e20E5675fbffDab2Fcda82E                                                                 |
|Dash:        | Xw5bDL93fFNHe9FAGHV4hjoGfDpfwsqAAj                                                                         |
|Zcash:       | t1a2Kr3jFv8WksgPBcMZFwiYM8Hn5QCMAs5                                                                        |
|PIVX:        | DQq2qeny1TveZDcZFWwQVGdKchFGtzeieU                                                                         |
|Ripple:      | rLHzPsX6oXkzU2qL12kHCH8G8cnZv1rBJh<br />Destination Tag: 2357564055                                        |
|Monero:      | 4GdoN7NCTi8a5gZug7PrwZNKjvHFmKeV11L6pNJPgj5QNEHsN6eeX3D<br />&#8618;aAQFwZ1ufD4LYCZKArktt113W7QjWvQ7CWDXrwM8yCGgEdhV3Wt|


// Steven Jenkins De Haro ("StevenJDH" on GitHub)

