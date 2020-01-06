factorial 1 = 1
factorial n = n * factorial (n-1)

term x i = (x^(2*i - 1) / fromIntegral (factorial (2*i - 1)))*(-1)^(i-1)
sin' x = sum [term x i | i <- [1..33]]
cos' x = sin'(x - 4.71238898038) --3pi/2
tan' x = sin(x)/cos(x)
trunc x = (fromIntegral (floor (x * t))) / t
    where t = 10^10 --show only 10 digits

main :: IO ()
main = do
    print $ trunc $ sin' (pi/2) --90deg, output ought to be 1 
     print $ trunc $ cos' (pi/3) --60deg, output ought to be 0.5
    print $ trunc $ tan' (pi/4) --45deg, output ought to be 1