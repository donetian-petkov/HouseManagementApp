function list_child_processes () {
    local ppid=$1;
    local current_children=$(pgrep -P $ppid);
    local local_child;
    if [ $? -eq 0 ];
    then
        for current_child in $current_children
        do
          local_child=$current_child;
          list_child_processes $local_child;
          echo $local_child;
        done;
    else
      return 0;
    fi;
}

ps 1036;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 1036 > /dev/null;
done;

for child in $(list_child_processes 1040);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/donetianpetkov/Documents/GitHub/PersonalManagementApp/PersonalManagementApp/bin/Debug/net6.0/0571c602da594bad91af5ad9dc744842.sh;
