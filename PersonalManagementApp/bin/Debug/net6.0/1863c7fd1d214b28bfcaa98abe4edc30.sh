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

ps 74764;
while [ $? -eq 0 ];
do
  sleep 1;
  ps 74764 > /dev/null;
done;

for child in $(list_child_processes 74771);
do
  echo killing $child;
  kill -s KILL $child;
done;
rm /Users/donetianpetkov/Documents/GitHub/PersonalManagementApp/PersonalManagementApp/bin/Debug/net6.0/1863c7fd1d214b28bfcaa98abe4edc30.sh;
